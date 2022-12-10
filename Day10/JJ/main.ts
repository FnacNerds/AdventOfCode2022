// const input = await Deno.readTextFile("testInput.txt", "utf-8");
const input = await Deno.readTextFile("input.txt", "utf-8");

const lines: string[] = input.split("\n");
let X = 1;
let cycles = 0;
let signal = 0;
let rows: string[] = ["#", "", "", "", "", "", ""];
let current = "#";
let line = 0;
for (let i = 0; i < lines.length; i++) {
  const element = lines[i];
  cycles++;
  line = Math.floor(cycles / 40);
  if (cycles % 40 === 20) {
    signal += cycles * X;
  }
  if ([X - 1, X, X + 1].includes(cycles - 40 * line)) {
    rows[line] += "#";
  } else rows[line] += ".";
  if (element.startsWith("noop")) {
    continue;
  } else if (element.startsWith("addx")) {
    cycles++;
    line = Math.floor(cycles / 40);
    if (cycles % 40 === 20) {
      signal += cycles * X;
    }
    X += +element.substring(5);
  }
  if ([X - 1, X, X + 1].includes(cycles - 40 * line)) {
    rows[line] += "#";
  } else rows[line] += ".";
}
// P1
console.log(signal);
console.log(rows);
