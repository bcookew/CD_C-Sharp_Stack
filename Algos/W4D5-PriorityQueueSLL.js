class PriNode {
    constructor(data, pri) {
        this.data = data;
        this.priority = pri;
        this.next = null;
    }
}

class PriorityQueueLL {
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
            arr.push([runner.data, runner.priority]);
            runner = runner.next;
        }
        console.log(arr);
        return arr;
    }
    
    enqueue(data, pri) {
        var newNode = new PriNode(data, pri);
        if(this.isEmpty()){
            this.length++
            this.head = newNode;
        } else if(this.head.priority > newNode.priority) {
            newNode.next = this.head;
            this.head = newNode;
            this.length++
        } else {
            var runner = this.head;
            while(runner.next != null && newNode.priority >= runner.next.priority){
                runner = runner.next;
            }
            this.length++
            newNode.next = runner.next;
            runner.next = newNode;
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
}

l1 = new PriorityQueueLL();
l1.enqueue(10,4);
l1.enqueue(9,3);
l1.enqueue(8,2);
l1.enqueue(7,1);
l1.enqueue(6,3);
l1.toArray();