
import copy
import string 
from itertools import permutations
import re


def set_all_possible_words():
    all_possible_words = []
    with open('./Misc/Misc_scripts/words.txt', 'r') as file:
        # print(file.readlines())
        all_possible_words = [word[:-2].upper() for word in file.readlines()]
    return all_possible_words

# List of Characters in sequence with a boolean flag saying whether we display the letters
# as hint on the screen
target_word_list = ["CAT", "ACT"]

# These will be added in the final characters list
target_word_characters = [[letter for letter in target_word] for target_word in target_word_list]

hint_characters_list = [["T"], ["T"]]
# A list representing at what position of the target string a 
# blank will be present in the game
# The positions are 0-based indices
# __T -> 0th and 1st position are empty and the player will fill them
blank_positions_list = [[0, 1], [0, 1]]

for index, hint_character_list in enumerate(hint_characters_list):
    for hint_character in hint_character_list:
        assert hint_character in target_word_list[index]

all_words = set_all_possible_words()
all_set_of_characters_to_be_displayed = []
for index, target_word in enumerate(target_word_list):
    blank_positions = blank_positions_list[index]
    hint_characters = hint_characters_list[index]
    letters = [c for c in string.ascii_uppercase]

    select_characters = copy.deepcopy(letters)

    # remove hint characters
    select_characters = [letter for letter in select_characters \
                        if letter not in hint_characters]

    ways_of_filling_characters = permutations(blank_positions)
    possible_word_regex = []
    all_regex_permutations_strings = []
    for way_of_filling_characters in ways_of_filling_characters:
        # print(way_of_filling_characters)
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
        word_search_regex = '^' + word_search_regex + '$'
        regex_compiler = re.compile(word_search_regex)
        # print(all_words)
        for word in all_words:
            if regex_compiler.search(word):
                all_possible_words_matching_regexs.append(word)
    for word in all_possible_words_matching_regexs:
        for letter in word:
            unique_characters_in_matched_words.add(letter)
    print(set(select_characters).union(set(target_word_characters[index])))
    print(unique_characters_in_matched_words)
    set_of_characters_to_be_displayed = list((set(select_characters) - unique_characters_in_matched_words).union(set(target_word_characters[index])))
    all_set_of_characters_to_be_displayed.append(set_of_characters_to_be_displayed)

with open('./Misc/Backend_data/word_puzzle_combination_per_level.json', 'w+') as json_file:
    levels = 10
    word_letter_combination_letter ={}
    for level in range(1, levels):
        word_letter_combination_letter[level] = []
        for index, word in enumerate(target_word_list):
            word_letter_combination_letter_object = {}
            word_letter_combination_letter_object['target_word'] = word
            word_letter_combination_letter_object['blanks'] = blank_positions_list[index]
            word_letter_combination_letter_object['letters'] = all_set_of_characters_to_be_displayed[index]
            word_letter_combination_letter[level].append(word_letter_combination_letter_object)
    # print(word_letter_combination_letter)
    import json 
    json.dump(word_letter_combination_letter, json_file, indent=4)






