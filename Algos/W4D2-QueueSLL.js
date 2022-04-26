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
    peek () {
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
            return temp.data;
        }
    }
}

var qll = new QueueLL();
console.log(qll.isEmpty());
qll.enqueue(1);
qll.enqueue(2);
qll.enqueue(3);
qll.enqueue(4);
console.log(qll.enqueue(5));
qll.toArray();
console.log(qll.dequeue());
console.log(qll.peek());
qll.toArray();
console.log(qll.isEmpty());