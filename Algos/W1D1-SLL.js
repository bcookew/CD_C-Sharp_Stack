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
                arr.push(runner.val)
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

    }
}