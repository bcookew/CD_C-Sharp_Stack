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
        // Given a value, return true or false whether that value is in your list
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

}

var ls = new SLL();
ls.add_to_front(3).add_to_front(2).add_to_front(1)
ls.to_array()
ls.add_to_back(4).add_to_back(5).add_to_back(6)
ls.to_array()
ls.removeHead()
ls.to_array()
ls.getAvg()
ls.removeBack()
ls.to_array()
var ls_two = new SLL();
ls_two.add_to_back(1);
ls_two.to_array();
ls_two.removeBack();
ls_two.to_array();
ls_two.add_to_back(1)
ls_two.to_array();

console.log(ls.contains(2));
console.log(ls.containsRecursively(2));
console.log("Should return 2 true ===================>");
console.log(ls_two.contains(1));
console.log(ls_two.containsRecursively(1));
console.log("Should return 2 false ===================>");
console.log(ls_two.contains(0));
console.log(ls_two.containsRecursively(0));