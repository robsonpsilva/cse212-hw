    def binary_search(list, i):
    left = 0
    right = len(list) - 1
    while left <= right:
        mid = (left + right) // 2
        if list[mid] == i:
        return mid
        elif list[mid] < i:
        left = mid + 1
        else:
        right = mid - 1
    return -1

    # Use example
    ordained_list = [1, 2, 3, 4, 10, 25, 40, 50, 100]
    i = 3

    result = binary_search(ordained_list, i)

    if result != -1:
    print("Element found in index", str(result))
    else:
    print("Element not found")