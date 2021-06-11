provider "aws" {
    access_key = var.access_key
    secret_key = var.secret_key
	region="us-east-2"
}

resource "aws_sns_topic" "my_first_sns_topic" { 
  name = var.sns_name
}
  
data "aws_iam_policy_document" "my_custom_sns_policy_document" {
  policy_id = "__default_policy_ID"

  statement {
    actions = [
      "SNS:Subscribe",
      "SNS:SetTopicAttributes",
      "SNS:RemovePermission",
      "SNS:Receive",
      "SNS:Publish",
      "SNS:ListSubscriptionsByTopic",
      "SNS:GetTopicAttributes",
      "SNS:DeleteTopic",
      "SNS:AddPermission",
    ]

    condition {
      test     = "StringEquals"
      variable = "AWS:SourceOwner"

      values = [
        var.account_id,
      ]
    }

    effect = "Allow"

    principals {
      type        = "AWS"
      identifiers = ["*"]
    }

    resources = [
      aws_sns_topic.my_first_sns_topic.arn,
    ]

    sid = "__default_statement_ID"
  }
}

resource "aws_sqs_queue" "aws_sqs_dl_queue" {
    name = "results-updates-dl-queue"
}

resource "aws_sqs_queue" "my_sqs_target_queue" {
    name = "mySQSQueue"
    redrive_policy  = "{\"deadLetterTargetArn\":\"${aws_sqs_queue.aws_sqs_dl_queue.arn}\",\"maxReceiveCount\":5}"
    visibility_timeout_seconds = 300

    tags = {
        Environment = "dev"
    }
}



# resources.tf
resource "aws_sns_topic_subscription" "my_sqs_target_queue" {
    topic_arn = "${aws_sns_topic.my_first_sns_topic.arn}"
    protocol  = "sqs"
    endpoint  = "${aws_sqs_queue.my_sqs_target_queue.arn}"
}

# resources.tf
resource "aws_sqs_queue_policy" "results_updates_queue_policy" {
    queue_url = "${aws_sqs_queue.my_sqs_target_queue.id}"

    policy = <<POLICY
	{
	  "Version": "2021-06-10",
	  "Id": "sqspolicy",
	  "Statement": [
		{
		  "Sid": "First",
		  "Effect": "Allow",
		  "Principal": "*",
		  "Action": "sqs:SendMessage",
		  "Resource": "${aws_sqs_queue.my_sqs_target_queue.arn}",
		  "Condition": {
			"ArnEquals": {
			  "aws:SourceArn": "${aws_sns_topic.my_first_sns_topic.arn}"
			}
		  }
		}
	  ]
	}
	POLICY
}
