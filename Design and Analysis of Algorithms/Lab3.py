import math
from sys import maxsize
from itertools import permutations

class Point:
    def __init__(self, x, y):
        self.x = x
        self.y = y

def D(A,B):
    tmp = 0
    for i in range(len(A)):
        tmp += pow(A[i]-B[i],2)
    return math.sqrt(tmp)



def E(A):
    n = len(A)
    if n < 3:
        return
    min = 0
    for i in range(1,n):
        if A[i].x < A[min].x :
            min = i
        elif A[i].x == A[min].x:
            if A[i].y > A[min].y:
                min = i
    hull = []
    p = min
    q = 0
    while(True):
        hull.append(p)
        q = (p+1)%n
        for i in range(n):
            val = (A[i].y - A[p].y)*(A[q].x - A[i].x) - (A[i].x - A[p].x)*(A[q].y - A[i].y)
            if val == 0:
                val = 0
            elif val > 0:
                val = 1
            else:
                val = 2
            if val == 2:
                q = i
        p = q
        if p == min:
                break
    return hull


# points = []
# points.append(Point(0, 3))
# points.append(Point(2, 2))
# points.append(Point(1, 1))
# points.append(Point(2, 1))
# points.append(Point(3, 0))
# points.append(Point(0, 0))
# points.append(Point(3, 3))


# for each in E(points):
#     print(points[each].x,points[each].y)

V = 4
def G(graph,s):
    vertex = []
    for i in range(V):
        if i != s:
            vertex.append(i)
    minPath = maxsize
    nextPermutation = permutations(vertex)
    for i in nextPermutation:
        currentPathWeight = 0
        k = s
        for j in i:
            currentPathWeight += graph[k][j]
            k = j
        currentPathWeight += graph[k][s]

        minPath = min(minPath, currentPathWeight)
    return minPath

graph = [[0, 10, 15, 20], [10, 0, 35, 25],
            [15, 35, 0, 30], [20, 25, 30, 0]]
s = 0
print(G(graph, s))




