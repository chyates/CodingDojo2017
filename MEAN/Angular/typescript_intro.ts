// -------------------------------------------------------------------------     --------------------------------------------------------------------------
// -                               TYPESCRIPT                              -     -                               JAVASCRIPT                               -
// -------------------------------------------------------------------------     --------------------------------------------------------------------------

// variable declaration
var myNum: number = 5;                                                      //-- myNum = 5;
var myString: string = "Hello Universe";                                    //-- myString = "Hello Universe";
var myArr: Array<number> = [1, 2, 3, 4];                                    //-- myArr = [1,2,3,4];
var myObj: object = { name: "Bill" };                                       //-- myObj = { name:'Bill'};
var anythingVariable: any = "Hey";                                          //-- anythingVariable = "Hey";
anythingVariable = 25;                                                      //-- anythingVariable = 25; 
myObj = {                                                                   //-- myObj = {   
    x: 5,                                                                   //--    x: 5,
    y: 10                                                                   //--    y: 10
};                                                                          //-- };
var arrayOne: Array<boolean> = [true, false, true, true];                   //-- arrayOne = [true, false, true, true]; 
var arrayTwo: Array<number | string | boolean> = [1, 'abc', true, 2];       //-- arrayTwo = [1, 'abc', true, 2];


// creating classes                                                         //-- 
class MyNode {                                                              //-- MyNode = (function () {
    value: number;                                                          //--
    left: object;                                                           //--
    right: object;                                                          //--
    _priv: number;                                                          //--
    constructor(val: number) {                                              //--    function MyNode(val) {
        this.value = val;                                                   //--        this.val = 0;
    }                                                                       //--        this.val = val;
                                                                            //--    }
    doSomething() {                                                         //--    MyNode.prototype.doSomething = function () {
        this._priv = 10;                                                    //--        this._priv = 10;
    };                                                                      //--    };
}                                                                           //--    return MyNode
                                                                            //-- }());
let myNodeInstance = new MyNode(1);                                         //-- myNodeInstance = new MyNode(1);
console.log(myNodeInstance.value);                                          //-- console.log(myNodeInstance.val);

// function that returns nothing: type void
function myFunction(): void {                                               //-- function myFunction() {}
    console.log("Hello World");                                             //--    console.log("Hello World");
    return;                                                                 //--    return;
}                                                                           // -- }

// ...vs function that never returns, ie. has
//       an unreachable endpoint: type never
function sendingErrors():never {                                            // -- function sendingErrors() {
    throw new Error('Error message');                                       // --   throw new Error('Error message');
}                                                                           // -- }