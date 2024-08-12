using System.Data;
using System.Diagnostics;
using System.Runtime.InteropServices.ComTypes;

namespace neetcode;

public class ValidSudoku
{
    public bool IsValidSudoku(char[][] board)
    {
        var buckets = Enumerable.Range(0, 27).Select(x => new HashSet<char>()).ToArray();

        for (int row = 0; row < board.Length; row++)
        {
            for (int col = 0; col < board.Length; col++)
            {
                var num = board[row][col];
                if (num == '.')
                    continue;
                if (buckets[ColumnIndex(col)].Contains(num) 
                    || buckets[RowIndex(row)].Contains(num) 
                    || buckets[BlockIndex(col, row)].Contains(num))
                    return false;
                buckets[ColumnIndex(col)].Add(num);
                buckets[RowIndex(row)].Add(num);
                buckets[BlockIndex(col, row)].Add(num);
            }
        }
            
        return true;

        int ColumnIndex(int column) => column;
        int RowIndex(int row) => 9 + row;
        int BlockIndex(int column, int row) => 18 + (column / 3) + (3 * (row / 3));
    } 

    [Fact]
    public void Valid()
    {
        char[][] board =  [
        ['1','2','.','.','3','.','.','.','.'],
        ['4','.','.','5','.','.','.','.','.'],
        ['.','9','8','.','.','.','.','.','3'],
        ['5','.','.','.','6','.','.','.','4'],
        ['.','.','.','8','.','3','.','.','5'],
        ['7','.','.','.','2','.','.','.','6'],
        ['.','.','.','.','.','.','2','.','.'],
        ['.','.','.','4','1','9','.','.','8'],
        ['.','.','.','.','8','.','.','7','9']
            ];

        Assert.True(IsValidSudoku(board));
    }

    [Fact]
    public void InvalidSameRow()
    {
        char[][] board = [
        ['1','1','.','.','3','.','.','.','.'],
        ['4','.','.','5','.','.','.','.','.'],
        ['.','9','.','.','.','.','.','.','3'],
        ['5','.','.','.','6','.','.','.','4'],
        ['.','.','.','8','.','3','.','.','5'],
        ['7','.','.','.','2','.','.','.','6'],
        ['.','.','.','.','.','.','2','.','.'],
        ['.','.','.','4','1','9','.','.','8'],
        ['.','.','.','.','8','.','.','7','9']
            ];

        Assert.False(IsValidSudoku(board));
    }

    [Fact]
    public void InvalidSameColumn()
    {
        char[][] board = [
        ['1','.','.','.','3','.','.','.','.'],
        ['1','.','.','5','.','.','.','.','.'],
        ['.','9','.','.','.','.','.','.','3'],
        ['5','.','.','.','6','.','.','.','4'],
        ['.','.','.','8','.','3','.','.','5'],
        ['7','.','.','.','2','.','.','.','6'],
        ['.','.','.','.','.','.','2','.','.'],
        ['.','.','.','4','1','9','.','.','8'],
        ['.','.','.','.','8','.','.','7','9']
            ];

        Assert.False(IsValidSudoku(board));
    }

    [Fact]
    public void InvalidSameBlock()
    {
        char[][] board = [
        ['1','.','.','.','3','.','.','.','.'],
        ['.','1','.','5','.','.','.','.','.'],
        ['.','9','.','.','.','.','.','.','3'],
        ['5','.','.','.','6','.','.','.','4'],
        ['.','.','.','8','.','3','.','.','5'],
        ['7','.','.','.','2','.','.','.','6'],
        ['.','.','.','.','.','.','2','.','.'],
        ['.','.','.','4','1','9','.','.','8'],
        ['.','.','.','.','8','.','.','7','9']
            ];

        Assert.False(IsValidSudoku(board));
    }
}