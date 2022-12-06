function hasDuplicates(a) {
  for (let i = 0; i < a.length; i++) {
    if (a.indexOf(a[i]) !== a.lastIndexOf(a[i])) {
      return true;
    }
  }
  return false;
}

const input = await Deno.readTextFile("input.txt", "utf-8");

// P1
for (let i = 3; i < input.length; i++) {
  if (!hasDuplicates([input[i - 3], input[i - 2], input[i - 1], input[i]])) {
    console.log(i);
    break;
  }
}

// P2
for (let i = 0; i < input.length - 13; i++) {
  if (!hasDuplicates(input.slice(i, i + 14))) {
    console.log(i + 14);
    break;
  }
}
