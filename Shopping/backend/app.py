# -*- coding: utf-8 -*-
from flask import Flask, jsonify,request
import pandas as pd
from io import StringIO
import os
import json
import logging

logging.basicConfig(level=logging.INFO)

app = Flask(__name__)

#lists=[]

#a little comment

def index():
    return "Hello, World!"
    

def read_lists():
    path = os.getcwd()
    filepath=path + "\\lists.json"
    f = open(filepath, "r")
    txt=f.read()
    lists = json.loads(txt)
    f.close()
    return lists
    

def save_lists(lists):
    path = os.getcwd()
    filepath=path + "\\lists.json"
    f=open(filepath,"w")
    lists_json=json.dumps(lists)
    f.write(lists_json)
    f.close()
    

@app.route("/api/lists", methods=["GET"])
def get_lists():
    #return jsonify({'tasks': tasks})
    lists=read_lists()
    return lists

    
@app.route("/api/list/<int:listID>", methods=["GET"])
def get_list(listID):
    #return jsonify({'tasks': tasks})
    lists= read_lists()
    
    return lists["lists"][listID]
    #aList=[x for x in lists if x.listID==listID]
    #return aList
    #return jsonify("result",aList)

    
@app.route("/api/list", methods=["POST"])
def save_list():
    newList = request.json["newList"]
    lists=read_lists()
    lists.append(newList)
    save_lists(lists)
    
    
@app.route("/api/list/<int:listID>", methods=["DELETE"])
def delete_list(listID):
    #return jsonify({'tasks': tasks})
    lists=read_lists()
    aList=[x for x in lists if x.listID==listID]
    lists.remove(aList)
    save_lists(lists)

    
    
if __name__ == '__main__':
    app.run(debug=True, use_reloader=False)

#app.run()
    
    
    

    

    