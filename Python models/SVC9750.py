from sklearn.svm import SVC
import numpy as np
from sklearn.model_selection import train_test_split
from sklearn.pipeline import make_pipeline
from sklearn.preprocessing import StandardScaler

f = open('InputFile.txt', 'r')

document = open('InputFile1.txt', 'r')

data_x = []
data_xNew = []

for line in f.readlines():
    line = line.strip()
    values = line.split(',')
    data_x.append(values)

for line in document.readlines():
    line = line.strip()
    values = line.split(',')
    data_xNew.append(values)

with open('OutputFile1.txt', 'r') as f:
    data_yNew = []
    for line in f:
        line = line.strip()
        data_yNew.append(int(line))

with open('OutputFile.txt', 'r') as f:
    data_y = []
    for line in f:
        line = line.strip()
        data_y.append(int(line))

split_index = int(0.05 * len(data_x))

data_x = np.array(data_x)
data_y = np.array(data_y)

#x_train, x_test, y_train, y_test = train_test_split(data_x,data_y, train_size=0.25, random_state=100, shuffle=False)
x_train, y_train = data_x[:split_index], data_y[:split_index]
x_test = data_xNew
y_test = data_yNew

clf = make_pipeline(StandardScaler(), SVC(gamma='scale'))
clf.fit(x_train, y_train)

variable = clf.predict(x_test)

TN=0
TP=0
FP=0
FN=0

for i in range(len(y_test)):
    if y_test[i] == variable[i] and y_test[i]==0:
        TN=TN+1
    elif y_test[i] == variable[i] and y_test[i]==1:
        TP=TP+1
    elif y_test[i] != variable[i] and y_test[i]==0:
        FP=FP+1
    elif y_test[i] != variable[i] and y_test[i]==1:
        FN=FN+1
        
print(variable)
print(y_test)
print('Test:' + str(len(y_test)))
Sum=TN+TP+FP+FN
print('Sum:' + str(Sum))
print('TN:' + str(TN))
print('TP:' + str(TP))
print('FP:' + str(FP))
print('FN:' + str(FN))