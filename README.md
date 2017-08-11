# AnagramCheckerApp

Takes two words or phrases and compares them to see if they are anagrams of each other.

There are two methods used to check: comparing ASCII values and comparing sorted characters as strings. The ASCII value method was derived by a friend and I implemented it to see if it worked. Unfortunately, there are test cases where ASCII values summed together are the same but the characters are different. As an example, "bcd" = "ccc" in ASCII, but are definitely not anagrams.
