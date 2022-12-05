const input = await Deno.readTextFile("input.txt", "utf-8");
// const input = await Deno.readTextFile("testInput.txt", "utf-8");

let countP1 = 0;
let countP2 = 0;

input.split("\n").map((i: string) => {
  const ranges = i.split(",");
  const start1 = Number(ranges[0].split("-")[0]);
  const end1 = Number(ranges[0].split("-")[1]);
  const start2 = Number(ranges[1].split("-")[0]);
  const end2 = Number(ranges[1].split("-")[1]);

  if (
    (start2 >= start1 && end2 <= end1) ||
    (start1 >= start2 && end1 <= end2)
  ) {
    countP1++;
  }

  if (
    (start1 >= start2 && end1 <= end2) ||
    (start2 >= start1 && end2 <= end1) ||
    (end1 >= start2 && end1 <= end2) ||
    (start1 >= start2 && start1 <= end2) ||
    (end2 >= start1 && end2 <= end1) ||
    (start2 >= start1 && start2 <= end1)
  ) {
    countP2++;
  }
});

console.log(countP1);
console.log(countP2);
