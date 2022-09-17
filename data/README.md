

## This file explains the structure of the json file which contains the word letter puzzle combinations generated using a python script.

The first key in the json is the level number.
The values is a list of all possible puzzle to be given to player.

Each puzzle has the target word, blank letters which are supposed to be blank in the target word are recognised using the character position. And the letters which can be kept in the level which will make the user derive the word to be the target word.


` 
{
    "1": [
        {
            "target_word": "CAT",
            "blanks": [0, 1],
            "letters": ["A", "C", "E", "D", "G", "I", "K", "J", "M", "L", "O", "N", "Q", "P", "R", "T", "W", "V", "Y", "X", "Z"]
        },
        {
            "target_word": "SAT",
            "blanks": [0, 1],
            "letters": ["A", "S", "T"]
        }
    ]
}
`