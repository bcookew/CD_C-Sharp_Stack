// Stacks are a last in first out structure

class QueueArr {
    constructor() {
        this.items = [];
    }
    isEmpty() {
        return this.items.length === 0;
    }
    size() {
        return this.items.length;
    }
    peek() {
        return this.items[0]
    }
    enqueue(item) {
        this.items.push(item);
        return this.size();
    }
    dequeue() {
        if(this.isEmpty()) {return null}
        return this.items.shift();
    }
}

qArr = new QueueArr();

class StackArr {
    constructor() {
        this.items = [];
    }
    isEmpty() {
        return this.items.length === 0;
    }
    push(item) {
        this.items.push(item);
        return this.size;
    }
    pop() {
        return this.items.pop();
    }
    size() {
        return this.items.length;
    }
    peek () {
        return this.items.length-1;
    }

}

class QueueNode {
    constructor(data) {
        this.data = data;
        this.next = null;
    }
}

class QueueLL {
    constructor() {
        this.head = null;
        this.length = 0;
    }
    isEmpty() {
        return this.length === 0;
    }
    size() {
        return this.length;
    }
    peek() {
        if(this.isEmpty()){return null}
        else{
            return this.head.data;
        }
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
    enqueue(item) {
        if(this.isEmpty()){
            this.head = new QueueNode(item);
            this.length++;
            return this.size();
        } else {
            var runner = this.head;
            while(runner.next){
                runner = runner.next;
            }
            runner.next = new QueueNode(item);
            this.length++;
            return this.size();
        }
    }
    dequeue() {
        if(this.isEmpty()) {
            return null;
        } else {
            var temp = this.head;
            this.head = this.head.next;
            this.length--;
            return temp.data;
        }
    }

    // Compare two queues
    compare(Q2) {
        if(this.size() != Q2.size()){
            console.log("If False Statement");
            return false;
        }
        for (var i = 0; i < this.length; i++) {
            var val1 = this.front();
            var val2 = Q2.front();
            if(val1 === val2){
                this.enqueue(this.dequeue());
                Q2.enqueue(Q2.dequeue());
            } else {
                console.log("ForLoop False Statement");
                return false;
            }
        }
        return true;
    }

    // Is queue a palindrome, also using only built in methods
    palindrome() {
        if(this.isEmpty()){
            return false;
        }

        var tempStack = new Stack();

        for (var i = 0; i < this.length; i++) {
            let temp = this.dequeue();
            tempStack.push(temp.data);
            this.enqueue(temp.data);
        }
        
        console.log(tempStack);

        for (var i = 0; i < this.length; i++) {
            let temp = this.front();
            let temp2 = tempStack.peek();
            console.log(temp, temp2);

            if( temp === temp2 ){
            this.enqueue(this.dequeue());
            tempStack.pop();
            } else {
                console.log("ForLoop False Statement");
                return false;
            }
        }
        return true;
    }

    // Sum of Halves Equal
    // Return true or false whether the sum of the front half of your queue is equal to the sum of the left half of your queue - as before, try to limit yourself to only built in methods within your queue class

    SumOfHalves() {
        if(this.isEmpty()) {
            console.log("IsEmptyFalse");
            return false;
        }
        else{
            // Set counting variables
            var sumL = 0;
            var sumR = 0;
            var len = this.size();
            for (var i = 1; i <= this.length; i++) {
                var temp = this.dequeue();
                if (len % 2 == 1 && i == Math.ceil(len/2)) {
                    sumL += temp;
                    sumR += temp;
                } else if(i<=len/2){
                    sumL += temp;
                } else {
                    sumR += temp;
                }
                this.enqueue(temp);
            }
            return sumL === sumR;
        }
    }

// Two Stack Queue
}

class TwoStackQueue {
    constructor() {
        this.stack1 = new StackArr();
        this.stack2 = new StackArr();
    }

    enqueue(item) {
        this.stack1.push(item);
    }

    dequeue() {
        console.log("\nUnload");
        while(this.stack1.items.length > 1){
            this.stack2.push(this.stack1.pop())
            console.log("Stack 1:", this.stack1.items);
            console.log("Stack 2:", this.stack2.items, "\n");
        }
        var temp = this.stack1.pop();
        console.log("\nReload");
        while(this.stack2.items.length > 0){
            this.stack1.push(this.stack2.pop())
            console.log("Stack 2:", this.stack2.items);
            console.log("Stack 1:", this.stack1.items, "\n");
        }
        return temp;
    }
}

// var qll = new QueueLL();
// console.log(qll.isEmpty());
// qll.enqueue(5);
// qll.enqueue(3);
// // qll.enqueue(3);
// qll.enqueue(4);
// console.log(qll.enqueue(5));
// // qll.toArray();
// // console.log(qll.dequeue());
// // console.log(qll.peek());
// qll.toArray();
// console.log(qll.SumOfHalves());

var TwoSQ = new TwoStackQueue();

TwoSQ.enqueue(1);
TwoSQ.enqueue(2);
TwoSQ.enqueue(3);
TwoSQ.enqueue(4);
console.log(TwoSQ);
console.log("Dequeued Value:", TwoSQ.dequeue(), "\n");
console.log(TwoSQ);