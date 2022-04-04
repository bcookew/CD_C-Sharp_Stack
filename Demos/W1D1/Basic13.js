// Write a function that takes an integer array and prints the AVERAGE of the values in the array.
// For example, with an array [2, 10, 3], your program should write 5 to the console.

function getAverage(arr) {
    let sum = 0;
    for(i = 0; i < arr.length; i++){
        sum += arr[i]
    }
    return sum / arr.length;
}

arr1 = [5,5,5,5,5,5,5,5];
console.log(getAverage(arr1));
