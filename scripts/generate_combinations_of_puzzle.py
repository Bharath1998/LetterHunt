
import copy
import string 
from itertools import permutations
import re

# List of Characters in sequence with a boolean flag saying whether we display the letters
# as hint on the screen
target_word = "CAT"

# These will be added in the final characters list
target_word_characters = [letter for letter in target_word]

hint_characters = ["T"]
# A list representing at what position of the target string a 
# blank will be present in the game
# The positions are 0-based indices
# __T -> 0th and 1st position are empty and the player will fill them
blank_positions = [0, 1]

for hint_character in hint_characters:
    assert hint_character in target_word

all_words = ["FAT", "SAT", "HAT", "BAT", "CUT"]

letters = [c for c in string.ascii_uppercase]

select_characters = copy.deepcopy(letters)

# remove hint characters
select_characters = [letter for letter in select_characters \
                    if letter not in hint_characters]

ways_of_filling_characters = permutations(blank_positions)
possible_word_regex = []
all_regex_permutations_strings = []
for way_of_filling_characters in ways_of_filling_characters:
    print(way_of_filling_characters)
    regex_of_current_sequence = bytearray(copy.deepcopy(target_word))

    for position in blank_positions:
        regex_of_current_sequence[position] = '.'
    for position in way_of_filling_characters:
        regex_of_current_sequence[position] = target_word[position]
        all_regex_permutations_strings.append(copy.deepcopy(regex_of_current_sequence))
        
word_search_regexs = [str(word_regex) for word_regex in all_regex_permutations_strings if word_regex != target_word]

all_possible_words_matching_regexs = []
unique_characters_in_matched_words = set()
for word_search_regex in word_search_regexs:
    regex_compiler = re.compile(word_search_regex)

    for word in all_words:
        if regex_compiler.search(word):
            all_possible_words_matching_regexs.append(word)
for word in all_possible_words_matching_regexs:
    for letter in word:
        unique_characters_in_matched_words.add(letter)
print(list(set(list(set(select_characters) - unique_characters_in_matched_words) + target_word_characters)))





