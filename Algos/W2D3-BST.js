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
        if(this.isEmpty()){
            console.log("List is empty");
            return false
        }
        else{
            var runner = this.root;
            while (runner != null){
                if(runner.data == val){
                    return true;
                }
                else if(val > runner.data){
                    runner = runner.right;
                }
                else{
                    runner = runner.left;
                }
            }
            return false
        }
    }

    // Contains recursive
    // Now that you've solved contains iteratively, solve it again but with recursion
    containsRecursive(val, runner=this.root){
        if(this.isEmpty() || runner == null){
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

    // Given a value, insert it into the correct location in the binary search tree
    insert(val){
        // your code here
        if(this.isEmpty()){
            this.root = new Node(val)
            return this
        }
        else{
            var walker = this.root;
            var runner = this.root;
            while (runner != null){
                if(val >= runner.data){
                    walker = runner;
                    runner = runner.right;
                }
                else{
                    walker = runner;
                    runner = runner.left;
                }
            }
            if(val >= walker.data){
                walker.right = new Node(val);
                return this;
            }
            else{
                walker.left = new Node(val);
                return this;
            }
        }
    }

    // Now that you've solved insert iteratively, write it recursively
    insertRecursive(val, runner=this.root, walker=this.root){
        // your code here
        if(this.isEmpty()){
            this.root = new Node(val)
            return this
        } 
        else if (runner == null){
            if(val >= walker.data){
                walker.right = new Node(val);
                return this;
            } 
            else {
                walker.left = new Node(val);
                return this;
            }
        } 
        else if (val >= runner.data){
            return this.insertRecursive(val, runner.right, runner)
        } 
        else {
            return this.insertRecursive(val, runner.left, runner)
        }
    }
}


var bst = new BST();
// console.log(bst.isEmpty());
console.log("First Insert");
bst.insertRecursive(23)
console.log("Second Insert");
// console.log(bst.isEmpty());
bst.insertRecursive(47)
// bst.insert(13)

console.log(bst.contains(47))
console.log(bst.contains(23))

// var nodeA = new Node(6);
// bst.root = nodeA;
// bst.root.left = new Node("4");
// bst.root.left.left = new Node("3");
// bst.root.left.right = new Node("5");
// bst.root.right = new Node("8");
// bst.root.right.left = new Node("7");
// bst.root.right.right = new Node("9");
// console.log(bst.isEmpty());
// console.log(bst.min())
// console.log(bst.max())
// var bst2 = new BST()
