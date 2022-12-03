function alphabetPosition(text) {
  const pos = text.charCodeAt(0);
  if (pos <= 90) {
    return pos - 38;
  }
  return pos - 96;
}

const input = await Deno.readTextFile("input.txt", "utf-8");
// const input = await Deno.readTextFile("testInput.txt", "utf-8");

// P1
let sum = 0;
input.split("\n").map((i: string) => {
  const cpt1 = [
    ...new Set(
      i
        .substring(0, i.length / 2)
        .split("")
        .sort(),
    ),
  ];
  const cpt2 = [
    ...new Set(
      i
        .substring(i.length / 2)
        .split("")
        .sort(),
    ),
  ];
  let hasCommonValue = false;
  cpt1.map((l) => {
    if (!hasCommonValue && cpt2.includes(l)) {
      sum += alphabetPosition(l);
      hasCommonValue = true;
    }
  });
});

console.log(sum);

// P2
const array = input.split("\n");
sum = 0;
for (let i = 0; i < array.length; i += 3) {
  let hasCommonValue = false;
  [...array[i]].map((l) => {
    if (
      !hasCommonValue &&
      array[i + 1].includes(l) &&
      array[i + 2].includes(l)
    ) {
      sum += alphabetPosition(l);
      hasCommonValue = true;
    }
  });
}

console.log(sum);
