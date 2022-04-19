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
    extractTop(){
        if(this.size() > 0) {
            var extracted = this.heap[1];
            this.heap[1] = this.heap.pop();
            console.log(this.heap);
            this.shiftDown();
            return extracted;
        }
        return null;
    }

    shiftDown(){
        var indexOfVal = 1;
        var left = indexOfVal * 2;
        var right = indexOfVal * 2 + 1;
        while(this.heap[indexOfVal] >= this.heap[left] || this.heap[indexOfVal] >= this.heap[right]){
            if(this.heap[left] < this.heap[right]){
                var temp = this.heap[indexOfVal];
                this.heap[indexOfVal] = this.heap[left];
                this.heap[left] = temp;
                indexOfVal = left;
                left = indexOfVal * 2;
                right = indexOfVal * 2 + 1;
            }
            else{
                var temp = this.heap[indexOfVal];
                this.heap[indexOfVal] = this.heap[right];
                this.heap[right] = temp;
                indexOfVal = right;
                left = indexOfVal * 2;
                right = indexOfVal * 2 + 1;
            }
        }
    }
}

var heap = new MinHeap();
heap.insert(3)
heap.insert(5)
heap.insert(9)
heap.insert(2)
heap.insert(10)
heap.insert(10)

console.log(heap.extractTop());
console.log(heap.heap);

