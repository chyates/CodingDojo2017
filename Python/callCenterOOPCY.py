#PART 1: CREATE CALL CLASS
    #ATTRIBUTES:
        #Unique ID, caller name, caller phone #, duration of call, reason for call

    #METHODS:
        #displayDetails: prints all call attributes

class Call(object):
    def __init__(self, ID, caller_name, caller_phone_num, call_length, call_reason):
        self.ID = ID
        self.caller_name = caller_name
        self.caller_phone_num = caller_phone_num
        self.call_length = call_length
        self.call_reason = call_reason

    def displayDetails(self):
        print 'Case ID: ' +str(self.ID)
        print 'Caller Name: ' +self.caller_name
        print 'Caller Phone Number: '+self.caller_phone_num
        print 'Call Length: ' +self.call_length
        print 'Call Reason: ' +self.call_reason

case1 = Call(101, 'John Smith', '312-123-4567', 'Two minutes six seconds', 'Connectivity problems')
case1.displayDetails()



#PART 2: CREATE CALLCENTER CLASS
    #ATTRIBUTES:
        #call log: list of call objects (aka the calls + their attributes)
        #queue: # of calls in list
    
    #METHODS:
        #addCall: add new call to end of list
        #removeCall: removes call from beginning of list (index of 0)
        #callInfo: prints name + phone # for each call in the queue, as well as length of queue

class CallCenter(Object):
    def __init__(self, amt_call_objs, call_queue):
        self.amt_call_objs = []
        self.call_queue = len(self.amt_call_objs)

    def addCall(self, call):

        print 'This call has been added to the queue'

    def removeCall(self, amt_call_objs):
        self.amt_call_objs.pop(0)
        print 'This call has been removed from the queue'