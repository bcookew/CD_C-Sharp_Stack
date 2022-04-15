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
    // fullTree
    //               root
    //            <-- 25 -->
    //          /            \
    //        15             50
    //      /    \         /    \
    //     10     22      35     70
    //   /   \   /  \    /  \   /  \
    // 4    12  18  24  31  44 66  90
    //

    // Depth First Search Preorder
    // Use your skills with BSTs to return an array that contains all the values in the tree using the concept of depth first search preorder. 
    // Preorder: [root][left][right] -> for each node of this tree, we will read the data of that node, then visit the left subtree and then the right subtree
    // Should get back [25, 15, 10, 4, 12, 22, 18, 24, 50, 35, 31, 44, 70, 66, 90]

    preOrder(treeClimber=this.root, arr=[]){
        if(treeClimber) {
            arr.push(treeClimber.data);
            this.preOrder(treeClimber.left, arr);
            this.preOrder(treeClimber.right, arr);
            return arr
        }
    }

    // Depth First Search Inorder
    // Now use your skills to return an array that contains all the values using DFS Inorder. 
    // Inorder: [left][root][right] -> for each node, visit the left subtree, then read the data of the node, then visit the right subtree
    // Should get back [4, 10, 12, 15, 18, 22, 24, 25, 31, 35, 44, 50, 66, 70, 90]
    inOrder(treeClimber=this.root, arr=[]){
        if(treeClimber) {
            this.inOrder(treeClimber.left, arr);
            arr.push(treeClimber.data);
            this.inOrder(treeClimber.right, arr);
            return arr
        }
    }

    // Depth First Search Postorder
    // Finally, return an array that contains all the values using DFS Postorder.
    // Postorder: [left][right][root] -> visit left subtree, right subtree, then visit and read the data of the node
    // Should get back [4, 12, 10, 18, 24, 22, 15, 31, 44, 35, 66, 90, 70, 50, 25]
    postOrder(treeClimber=this.root, arr=[]){
        if(treeClimber) {
            this.inOrder(treeClimber.left, arr);
            this.inOrder(treeClimber.right, arr);
            arr.push(treeClimber.data);
        }
        return arr
    }
    
    size(treeClimber=this.root){
        if(treeClimber) {
            return this.preOrder().length;
        }
        return 0;
    }

    size2(treeClimber=this.root, count=0){
        if(treeClimber){
            count++
            count += this.size2(treeClimber.left) + this.size2(treeClimber.right)
        }
        return count
    }
    height(treeClimber=this.root, depth=0, max=0){
        // console.log(depth);
        if(!treeClimber){return 0;}
        else{
            return 1 + Math.max(this.height(treeClimber.left),this.height(treeClimber.right));
        };
    };
    
}   

// [25, 15, 10, 4, 12, 22, 18, 24, 50, 35, 31, 44, 70, 66, 90]
var bst = new BST();
console.log("First Insert");
bst.insertRecursive(25).insertRecursive(15).insertRecursive(10).insertRecursive(4).insertRecursive(12).insertRecursive(22).insertRecursive(18).insertRecursive(24).insertRecursive(50).insertRecursive(35).insertRecursive(31).insertRecursive(44).insertRecursive(70).insertRecursive(66).insertRecursive(90);
// console.log("In Order");
// console.log(bst.inOrder());
// console.log(bst.size());
console.log(bst.height());