// Stacks are a last in first out structure

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

s1 = new StackArr();

class StackNode {
    constructor(data) {
        this.data = data;
        this.next = null;
    }
}

class StackLL {
    constructor() {
        this.head = null;
        this.length = 0;
    }
    
    // IsEmpty
    isEmpty() {
        return this.head === null;
    }

    // Add Value
    push(val) {
        var newNode = new StackNode(val);
        if(this.isEmpty()) {
            this.head = newNode;
            this.length++;
            return this.size();
        }
        else {
            var runner = this.head;
            while(runner.next) {
                runner = runner.next;
            }
            runner.next = newNode;
            this.length++;
            return this.size();
        }
    }
    // Remove Value
    pop() {
        var newNode = new StackNode(val);
        if(this.isEmpty()) {
            return null;
        }
        else if (this.head.next == null) {
            var tempData = this.head.data;
            this.head = null;
            this.length--;
            return tempData;
        }
        else {
            var runner = this.head;
            while(runner.next.next) {
                runner = runner.next;
            }
            var tempData = runer.next.data;
            runner.next = null;
            this.length--;
            return tempData;
        }
    }
    // Peek Top Val
    peek() {
        if(this.isEmpty()) {
            return null;
        }
        var runner = this.head;
        while(runner.next) {
            runner = runner.next;
        }
        return runner.data;
    }

    // Size
    size () {
        return this.length;
    }
}

var sll = new StackLL();
console.log(sll.push(1));
console.log(sll.push(2));
console.log(sll.push(3));
console.log(sll.push(4));
console.log(sll.push(5));