const input = await Deno.readTextFile("input.txt", "utf-8");
let final = [];
let temp = 0;
let max = 0;
const array = input.split("\n").map((m) => {
  if (!Number(m)) {
    final.push(temp);
    if (temp > max) {
      max = temp;
    }
    temp = 0;
  } else {
    temp += Number(m);
  }
});
final.sort((a, b) => b - a);
// P1
console.log(final[0]);
// P2
console.log(final[0] + final[1] + final[2]);
