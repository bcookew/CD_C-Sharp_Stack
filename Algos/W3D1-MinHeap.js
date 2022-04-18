class MinHeap {
    constructor() {
        this.heap = [null];
    }
    size() {
        return this.heap.length - 1;
    }
    top() {
        return this.size() > 0 ? this.heap[1] : null;
    }
    insert(num) {
        this.heap.push(num);
        console.log("Insert:",this.heap);
        this.shiftUp();
        return this.size();
    }
    shiftUp(indexOfVal = this.heap.length-1) {
        if(indexOfVal > 1) {
            var pIndex = Math.trunc(indexOfVal/2)
            if (this.heap[indexOfVal] < this.heap[pIndex]) {
                var temp = this.heap[indexOfVal];
                this.heap[indexOfVal] = this.heap[pIndex];
                this.heap[pIndex] = temp;
                return this.shiftUp(pIndex)
            }
        }
        console.log("Shift: ",this.heap);
        return indexOfVal
    }
}

var heap = new MinHeap();
heap.insert(3)
heap.insert(5)
heap.insert(9)
heap.insert(2)
