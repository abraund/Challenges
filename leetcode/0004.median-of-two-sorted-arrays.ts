function findMedianSortedArrays(nArr: number[], mArr: number[]): number {    
    let n = nArr.length;
    let m = mArr.length;
    if(m > n)
        return findMedianSortedArrays(mArr, nArr);
    let nmLength = n + m;

    return getKth(nArr, mArr, 0, nArr.length - 1);
};

function getKth(nArr: number[], mArr: number[], nBinChopLeft: number, nBinChopRight: number) : number
{
    let n = nArr.length;
    let m = mArr.length;
    let nmLength = n + m;
    let nmIsOdd = nmLength % 2 !== 0;
    let nGuess = nBinChopLeft + ((nBinChopRight - nBinChopLeft) / 2) | 0;
    let nVal = nArr[nGuess];
    
    if(mArr.length === 0)
        return (nVal + (nmIsOdd ? nVal : nArr[nGuess + 1])) / 2;

    let nValNext = nGuess + 1 < nArr.length ? nArr[nGuess+1] : undefined;
    let mGuess = ((nmLength / 2) - nGuess - 1) | 0;
    let mVal = mArr[mGuess];
    let mValNext = mGuess + 1 < mArr.length ? mArr[mGuess+1] : undefined;

    if(nVal <= mVal && nValNext !== undefined && nValNext >= mVal) //if one higher than me is also less than the net
        return (nVal + (nmIsOdd ? nVal : mVal)) / 2; 
    
    if(nVal >= mVal && mValNext !== undefined && nVal <= mValNext
        || nVal >= mVal && mValNext === undefined)
        return (nVal + (nmIsOdd ? nVal : mVal)) / 2;     
    
    if(nVal < mVal)
        return getKth(nArr, mArr, nGuess + 1, nBinChopRight);
    else 
        return getKth(nArr, mArr, nBinChopLeft, nGuess + 1);
}

function findMedian2(nums: number[][]){

    let activeArrays: number[][] = [];
    let operatingArray: number[] = nums[0];
    let totalLength = 0;

    for(let array of nums)
    {
        if(array.length === 0)
            continue;

        activeArrays.push(array);
        totalLength += array.length;
        operatingArray = array.length > operatingArray.length ? array : operatingArray;
    }

    while(true)
    {
        
    }

}

test('it is the median not the mean', () => {
    let x = findMedianSortedArrays([4,3], [2]) // look +1 on nums1, for comparison
    expect(x).toBe(3);
});

test('empty array', () => {
    let x = findMedianSortedArrays([4], [])
    expect(x).toBe(4);
});

test('empty array', () => {
    let x = findMedianSortedArrays([1, 3], [])
    expect(x).toBe(2);
});

test('it is the median not the mean', () => {
    let x = findMedianSortedArrays([2,3], [4]) // look +1 on nums1, for comparison
    expect(x).toBe(3);
});

test('it is the median not the mean', () => {
    let x = findMedianSortedArrays([3], [5]) // look +1 on nums1, for comparison
    expect(x).toBe(4);
});

test('it is the median not the mean', () => {
    let x = findMedianSortedArrays([2,3], [5,6]) // look +1 on nums1, for comparison
    expect(x).toBe(4);
});

test('it is the median not the mean', () => {
    let x = findMedianSortedArrays([2,3], [4]) // look +1 on nums1, for comparison
    expect(x).toBe(3);
});

