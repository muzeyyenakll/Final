from figures import triangle

# Test cases
test_cases = [
    (3, 4, 5),
    (2, 2, 2),
    (3, 4, 6),
    (6, 8, 10),
    (5, 12, 13)
]

# Check each test case
for a, b, c in test_cases:
    result = triangle(a, b, c)
    print(f"triangle({a}, {b}, {c}) -> {result}")
