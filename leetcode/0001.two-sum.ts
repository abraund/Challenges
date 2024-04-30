console.log('result: [' + twoSum([1,1,20,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,80,1,1,1,1,1,1,1,1,1,1], 100) + '], expected: [4,5]');

function twoSum(nums: number[], target: number): number[] {
    let hash: Record<number, number> = {}
    for(let i = 0; i < nums.length; i++)
    {
        let current = nums[i];
        let partner = target - current;
        let partnerIndex = hash[partner];
        if(partnerIndex !== undefined)
            return [partnerIndex, i];
        hash[nums[i]] = i;
    }
    throw new Error("cannot get here");
};