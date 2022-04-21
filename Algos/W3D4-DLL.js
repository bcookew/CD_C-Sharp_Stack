class Node {
    constructor(val) {
        this.data = val;
        this.next = null;
        this.prev = null;
    }
}

class DLL {
    constructor() {
        this.head = null;
        this.tail = null;
    }

    isEmpty() {
        return this.head == null && this.tail == null;
    }

    toArray() {
        var arr = [];
        var runner = this.head;
        while(runner) {
            arr.push(runner.data);
            runner = runner.next;
        }
        console.log(arr);
        return arr;
    }

    // Insert at Front
    // Insert a given value to the front of the doubly linked list
    InsertAtFront(val) {
        if (this.isEmpty()) {
            newNode = new Node(val);
            this.head = newNode;
            this.tail = newNode;
            return this;
        } else {
            newNode = new Node(val);
            newNode.next = this.head;
            this.head.prev = newNode;
            this.head = newNode;
            return this;
        }
    }

    // Insert at Back
    // Insert a given value to the back of the doubly linked list
    InsertAtBack(val) {
        if (this.isEmpty()) {
            var newNode = new Node(val);
            this.head = newNode;
            this.tail = newNode;
            return this;
        } else {
            var newNode = new Node(val);
            newNode.prev = this.tail;
            this.tail.next = newNode;
            this.tail = newNode;
            return this;
        }
    }

    // Remove Middle Node
    // Remove the node in the middle of your doubly linked list
    RemoveMiddle() {
        if (this.isEmpty()) {
            return null;
        } else {
            var fRunner = this.head;
            var bRunner = this.tail;
            while(fRunner != bRunner) {
                if(fRunner.next == bRunner){
                    bRunner.prev = fRunner.prev;
                    fRunner.prev.next = bRunner;
                    return fRunner;
                }
                fRunner = fRunner.next;
                bRunner = bRunner.prev;
            }
            fRunner.next.prev = fRunner.prev
            fRunner.prev.next = fRunner.next
            return fRunner;
        }
    }

    // Insert After
    // Insert a given value after another given value
    InsertAfter(val, valB) {
        var runner = this.head
        while (runner) {
            if (runner.value == valB) {
                if (runner==this.tail) {
                    this.insertAtBack(val)
                } else {
                    var newNode = new Node(val);
                    runner.next.previous = newNode;
                    newNode.next = runner.next
                    runner.next = newNode;
                    newNode.previous = runner;
                }
            }
            runner = runner.next
        }
    }

    // Insert Before
    // Insert a given value before another given value
    InsertBefore(val, valB) {
        // your code here
        var runner = this.head;
        while (runner) {
            if (runner.value == valB) {
                //if runner is also the head
                if (runner==this.head) {
                    this.insertAtFront(val)
                } else {
                    //make a new node if we find valB
                    var newNode = new Node(val);
                    //change all the pointers around
                    runner.previous.next = newNode;
                    newNode.previous = runner.previous;
                    runner.previous = newNode;
                    newNode.next = runner;
                }
            }
            runner = runner.next
        }
    }
}

var mydll = new DLL();
mydll.InsertAtBack(5).InsertAtBack(4).InsertAtBack(3).InsertAtBack(2).InsertAtBack(1)
mydll.toArray();