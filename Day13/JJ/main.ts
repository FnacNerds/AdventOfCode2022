function compare(l1, l2) {
  // unique numbers
  if (typeof l1 === "number" && typeof l2 === "number") {
    return l1 < l2 ? true : l1 > l2 ? false : undefined;
  } else if (typeof l1 === "object" && typeof l2 === "object") {
    for (let i = 0; i < l1.length && i < l2.length; i++) {
      let res = compare(l1[i], l2[i]);
      if (res !== undefined) return res;
    }
    return l1.length < l2.length
      ? true
      : l1.length > l2.length
      ? false
      : undefined;
  } else {
    return compare(
      typeof l1 === "number" ? [l1] : l1,
      typeof l2 === "number" ? [l2] : l2
    );
  }
}

let input = await Deno.readTextFile("input.txt", "utf-8");
// let input = await Deno.readTextFile("testInput.txt", "utf-8");

input = input
  .replace(/(\r)/gm, "")
  .split("\n")
  .filter((n) => n)
  .map(eval);
let count = 0;
let pairIndex = 0;

// only P2
let e1 = [[2]];
let e2 = [[6]];
input.push(e1);
input.push(e2);
// ^^^ only P2

// console.log(input);
let sortedInput = input.sort((a, b) => {
  let cmp = compare(a, b);
  if (cmp === undefined) {
    return undefined;
  }
  return cmp ? -1 : 1;
});
// console.log(sortedInput);
console.log((sortedInput.indexOf(e1) + 1) * (sortedInput.indexOf(e2) + 1));
// P1
// for (let i = 0; i < input.length; i += 3) {
//   pairIndex++;
//   const l1 = input[i];
//   const l2 = input[i + 1];
//   if (compare(eval(l1), eval(l2))) {
//     count += pairIndex;
//     console.log(pairIndex);
//   }
// }
console.log(count);
