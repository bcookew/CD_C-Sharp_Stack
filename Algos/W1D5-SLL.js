// Node Class
class Node {
    constructor(val){
        this.data = val;
        this.next = null;
    };
};

// SLL Class
class SLL {
    constructor(){
        this.head = null;
    };

    // SLL Methods
    // Is the list empty
    is_empty(){
        return this.head == null; // If the head is null return True else Return False
    }
    // Send node values to Array for printing
    to_array(){
        if(this.is_empty()){
            console.log("Empty List!");
        } else{
            let arr = [];
            var runner = this.head;
            while(runner){
                arr.push(runner.data)
                runner = runner.next
            }
            console.log(arr);
        }
    }
    // Add to end of SLL
    add_to_back(val){
        if(this.is_empty()){
            this.head = new Node(val)
        } else {
            var runner = this.head;
            while (runner.next != null){
                runner = runner.next
            }
            runner.next = new Node(val)
        }
        return this
    }
    add_to_front(val){
        if(this.is_empty()){
            this.head = new Node(val)
        } else {
            let newNode = new Node(val);
            newNode.next = this.head;
            this.head = newNode
        }
        return this
    }
    removeHead(){
        if(this.is_empty()){
            console.log("Mate! The list's empty mate...");
            return null
        }
        else{
            var currentHead = this.head;
            this.head = this.head.next;
            return currentHead;
        }

    }
        // Given a data, return true or false whether that data is in your list
    contains(val){
        if(this.is_empty()){
            console.log("The list is empty");
            return false;
        } else{
            var runner = this.head;
            while (runner != null){
                if(runner.data == val){return true}
                runner = runner.next
            }
        }
        return false
    }

    containsRecursively(val, node=this.head){
        if(this.is_empty()){
            console.log("The list is empty");
            return false;
        }
        if(node.data == val){return true}
        else if(node.next == null) {return false}
        else{
            node = node.next;
            return this.containsRecursively(val, node)
        }
    }

    // If you didn't already come up with the solution recursively, try that now! Or, if you did solve it recursively, how might you do it iteratively? 

    // Remove and return the last value in your list
    removeBack(){
        if(this.is_empty()){
            console.log("The list is empty");
            return false;
        } else if(this.head.next == null) {
            let node = this.head;
            this.head = null;
            return node;
        } else{
            var runner = this.head;
            while (runner.next.next != null){
                runner = runner.next;
            }
            let node = runner.next;
            runner.next = null;
            return node;
        };
    };
    getAvg(){
        if(this.is_empty()){
            console.log("Empty List!");
            return 0;
        } else{
            let sum = 0;
            let count = 0;
            var runner = this.head;
            while(runner){
                sum += runner.data;
                count++;
                runner = runner.next;
            }
            console.log(`The avg of the list is ${sum/count}`);
        }
    }
    getSecondToLastVal(){
        if(this.is_empty()){
            console.log("The list is empty");
            return false;
        } else if(this.head.next == null) {
            console.log("Only one node in list!");
            return node.data;
        } else{
            var runner = this.head;
            while (runner.next.next != null){
                runner = runner.next;
            }
            return runner.data;
        }
    }
    removeVal(val){
        if (!this.contains(val)){
            return false;
        } else if(this.head.data == val) {
            this.removeHead()
            return true
        } else{
            var runner = this.head;
            while (runner.next.data != val){
                runner = runner.next;
            }
            runner.next = runner.next.next;
            return true;
        };
    };
    removeAllValRecursive(val){
        if (!this.contains(val)){
            return false;
        } else if(this.head.data == val) {
            this.removeHead();
            this.removeAllValRecursive(val);
            return true;
        } else{
            var runner = this.head;
            while (runner.next.data != val){
                runner = runner.next;
            }
            runner.next = runner.next.next;
            this.removeAllValRecursive(val);
            return true;
        };
    };
    concat(sll){
        if (sll.is_empty()) {
            console.log("Nothing to concat!");
            return false
        } else if(this.is_empty()){
            this.head = sll.head;
            sll.head = null;
            return true;
        } else {
            var runner = this.head;
            while (runner.next != null){
                runner = runner.next
            }
            runner.next = sll.head;
            sll.head = null;
            return true;
        }
    }

    minToFront() {
        if (this.is_empty() || this.head.next == null) {
            console.log("Nothing to move!");
            return false
        }
        let runner = this.head
        let temp = runner.data
        while (runner.next != null) {
            if (temp > runner.next.data) {
                temp = runner.next.data
            }
            runner = runner.next
        }
        this.removeVal(temp)
        this.add_to_front(temp)
        return true
    }

    splitList(val){
        if (this.is_empty()) {
            console.log("Nothing to split!");
            return false;
        } else if (!this.contains(val)) {
            console.log("Value not in list!");
            return false
        } else if (this.head.data == val) {
            var sll2 = new SLL()
            sll2.head = this.head;
            this.head = null;
            return sll2;
        } else {
            var runner = this.head;
            while (runner.next != null){
                if(runner.next.data == val){break}
                runner = runner.next
            }
            var sll2 = new SLL()
            sll2.head = runner.next;
            runner.next = null;
            return sll2;
        }
    }
}

var ls = new SLL();
ls.add_to_front(3).add_to_front(2).add_to_front(9)
// ls.to_array()
ls.add_to_back(4).add_to_back(5).add_to_back(6)
// ls.to_array()
var ls2 = new SLL();
ls2.add_to_front(3).add_to_front(2).add_to_front(1)
ls2.add_to_back(4).add_to_back(5).add_to_back(6)
// ls2.to_array()
ls.concat(ls2)
ls.to_array()
var sll = ls.splitList(9)
ls.to_array()
sll.to_array()
// ls.minToFront()
// ls.to_array()

// // ls2.to_array()
// var ls3 = new SLL()
// ls.concat(ls3)
// ls3.concat(ls)
// ls3.to_array()
