function twoSum(nums: number[], target: number): number[] {
    let hash: Record<number, number> = {}
    for (let i = 0; i < nums.length; i++) {
        let current = nums[i];
        let partner = target - current;
        let partnerIndex = hash[partner];
        if (partnerIndex !== undefined)
            return [partnerIndex, i];
        hash[nums[i]] = i;
    }
    throw new Error("cannot get here");
};

describe('two sum', () => {
    test('find complements that add to 100', () => {
        let x = twoSum([1, 2, 20, 4, 5, 6, 7, 8, 9, 10, 80, 12, 13, 14, 15], 100);
        expect(x[0]).toBe(2)
        expect(x[1]).toBe(10)
    });
});