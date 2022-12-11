const input = await Deno.readTextFile("input.txt", "utf-8");

const lines: string[] = input.split("\n");

// let items = [[79, 98], [54, 65, 75, 74], [79, 60, 97], [74]];
// let divisors = [23, 19, 13, 17];
// let ops = [
//   (o) => (o = o * 19),
//   (o) => (o = o + 6),
//   (o) => (o = o * o),
//   (o) => (o = o + 3),
// ];
// let throws = [
//   [2, 3],
//   [2, 0],
//   [1, 3],
//   [0, 1],
// ];
// let count = [0, 0, 0, 0];

let items = [
  [93, 98],
  [95, 72, 98, 82, 86],
  [85, 62, 82, 86, 70, 65, 83, 76],
  [86, 70, 71, 56],
  [77, 71, 86, 52, 81, 67],
  [89, 87, 60, 78, 54, 77, 98],
  [69, 65, 63],
  [89],
];
let divisors = [19, 13, 5, 7, 17, 2, 3, 11];
let ops = [
  (o) => (o *= 17),
  (o) => (o += 5),
  (o) => (o += 8),
  (o) => (o += 1),
  (o) => (o += 4),
  (o) => (o *= 7),
  (o) => (o += 6),
  (o) => (o *= o),
];
let throws = [
  [5, 3],
  [7, 6],
  [3, 0],
  [4, 5],
  [1, 6],
  [1, 4],
  [7, 2],
  [0, 2],
];
let count = [0, 0, 0, 0, 0, 0, 0, 0];

const divisorsP2 = divisors.reduce((a, b) => a * b, 1);
console.log("SDFSDFSDF");
console.log(divisorsP2);
for (let i = 0; i < 10000; i++) {
  for (let m = 0; m < divisors.length; m++) {
    // console.log("ITEMS before");
    // console.log(items);
    if (items[m].length === 0) continue;
    while (items[m].length > 0) {
      let item = items[m].shift();
      let wl = ops[m](item);
      //   console.log(wl);
      //   wl = Math.floor(wl / 3);
      wl = wl % divisorsP2;
      //   console.log(wl);
      if (wl % divisors[m] === 0) {
        items[throws[m][0]].push(wl);
      } else {
        items[throws[m][1]].push(wl);
      }
      count[m]++;
    }
    // console.log("ITEMS after");
    // console.log(items);
  }
}
console.log(count.sort());
