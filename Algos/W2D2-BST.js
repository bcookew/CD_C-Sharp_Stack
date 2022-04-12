// Binary Search Tree Algorithms

class Node {
    constructor(val){
        this.data = val;
        this.left = null;
        this.right = null;
    }
}

class BST {
    constructor(){
        this.root = null;
    }

    isEmpty(){
        return this.root == null;
    }

    addNode(val){
        if(this.isEmpty()){
            this.root = new Node(val)
            return this
        }

    }

    min(){
        if(this.isEmpty()){
            console.log("Empty Tree");
            return this;
        }
        else {
            var runner = this.root;
            while(runner.left != null){
                runner = runner.left
            }
            return runner.data;
        }
    }
    max(){
        if(this.isEmpty()){
            console.log("Empty Tree");
            return this;
        }
        else {
            var runner = this.root;
            while(runner.right != null){
                runner = runner.right;
            }
            return runner.data;
        }
    }
    // Contains
    // Given a value, return true or false whether that value is contained in the tree
    contains(val){
        if(this.isEmpty){
            console.log("List is empty");
            return false
        }
        else{
            var runner = this.root;
            while (runner != null){
                if(runner.data == val){return true}
                else if(runner.data > val){
                    runner = runner.right;
                }
                else{runner = runner.left}
            }
            return false
        }
    }

    // Contains recursive
    // Now that you've solved contains iteratively, solve it again but with recursion
    containsRecursive(val, runner=this.root){
        if(this.isEmpty || runner == null){
            return false
        }
        else if(runner.data == val){
            return true
        }
        else if(runner.data > val){
            runner = runner.right;
            return this.containsRecursive(val, runner)
        }
        else{
            runner = runner.left
            return this.containsRecursive(val, runner)
        }
    }
    // Range
    // Calculate the range of the values in your tree by subtracting the max value from the min value
    range(){
        return Math.abs(this.max())-Math.abs(this.min());
    }
}


var bst = new BST();
console.log(bst.isEmpty());
var nodeA = new Node(6);
bst.root = nodeA;
bst.root.left = new Node("4");
bst.root.left.left = new Node("3");
bst.root.left.right = new Node("5");
bst.root.right = new Node("8");
bst.root.right.left = new Node("7");
bst.root.right.right = new Node("9");
console.log(bst.isEmpty());
console.log(bst.min())
console.log(bst.max())
var bst2 = new BST()
