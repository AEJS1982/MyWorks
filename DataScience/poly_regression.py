import numpy
from sklearn.metrics import r2_score
import matplotlib.pyplot as plt

#x=day of month , y=sales in USDs
x = [1,2,3,4,5,6,7,8,9,10,11,12]
y = [1000,2000,1500,500,300,1000,1200,700,900,1200,2000,2500]

mymodel = numpy.poly1d(numpy.polyfit(x, y, 5))

myline = numpy.linspace(1,12,2500)

plt.title("Sales per month")
plt.xlabel("Month",fontsize=20)
plt.ylabel("Sales in USD",fontsize=20)
plt.scatter(x, y)
plt.plot(myline, mymodel(myline),color='blue')
plt.show()

print("r2 score:" + str(r2_score(y, mymodel(x))))
