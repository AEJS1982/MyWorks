# -*- coding: utf-8 -*-
#K-MEANS Example with computer features and pricing data

import numpy as np
import pandas as pd
import matplotlib.pyplot as plt
import seaborn as sb
from sklearn.cluster import KMeans
from sklearn.metrics import pairwise_distances_argmin_min
 
from mpl_toolkits.mplot3d import Axes3D
plt.rcParams['figure.figsize'] = (16, 9)
plt.style.use('ggplot')

df=pd.read_csv("C:\\TEMP\\computers.csv")
X = np.array(df[["cpu_speed","ram","hd"]])
y = np.array(df["price"])

kmeans = KMeans(n_clusters=5).fit(X)
centroids = kmeans.cluster_centers_
#print(centroids)

labels = kmeans.predict(X)
df["cluster"]=labels

print("Average values per cluster:")
print(df.groupby("cluster")["cpu_speed","ram","hd","price"].mean())

print(df.head(5))
# Getting the cluster centers
C = kmeans.cluster_centers_
colores=['red','green','blue','cyan','yellow']
#colores=['red','green','blue']
asignar=[]
for row in labels:
    asignar.append(colores[row])
 
fig = plt.figure()
ax = Axes3D(fig)
ax.set_xlabel("CPU Speed", fontsize=20, rotation=150)
ax.set_ylabel("RAM", fontsize=20, rotation=60)
ax.set_zlabel("HD", fontsize=20, rotation=60)
ax.scatter(X[:, 0], X[:, 1], X[:, 2], c=asignar,s=60)
ax.scatter(C[:, 0], C[:, 1], C[:, 2], marker='*', c=colores, s=1000)

plt.show()

