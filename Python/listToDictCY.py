name = ["Carolyn", "Morgan", "Anne", "Kevin"]
birthstone = ["Diamond", "Garnet", "Peridot", "Topaz"]

def makeDict(arr1, arr2):
  myDict = {}
  for i in range (0, len(arr1)):
    myDict[arr1[i]] = arr2[i]
  print myDict
  
makeDict(name,birthstone)