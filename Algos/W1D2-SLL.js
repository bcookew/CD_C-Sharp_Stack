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

ls = new SLL();
ls.add_to_front(3).add_to_front(2).add_to_front(1)
ls.to_array()
ls.add_to_back(4).add_to_back(5).add_to_back(6)
ls.to_array()
ls.removeHead()
ls.to_array()
ls.getAvg()