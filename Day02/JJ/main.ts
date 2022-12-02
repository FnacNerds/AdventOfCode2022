const input = await Deno.readTextFile("input.txt", "utf-8");

let rockOrLose = ["A", "X"];
let paperOrDraw = ["B", "Y"];
let scissorsOrWin = ["C", "Z"];

let score = 0;
let score2 = 0;
// P1
input.split("\n").map((i) => {
  if (rockOrLose.includes(i[0])) {
    if (rockOrLose.includes(i[2])) {
      score += 4;
      score2 += 3;
    }
    if (paperOrDraw.includes(i[2])) {
      score += 8;
      score2 += 4;
    }
    if (scissorsOrWin.includes(i[2])) {
      score2 += 8;
      score += 3;
    }
  }

  if (paperOrDraw.includes(i[0])) {
    if (rockOrLose.includes(i[2])) {
      score += 1;
      score2 += 1;
    }
    if (paperOrDraw.includes(i[2])) {
      score += 5;
      score2 += 5;
    }
    if (scissorsOrWin.includes(i[2])) {
      score += 9;
      score2 += 9;
    }
  }

  if (scissorsOrWin.includes(i[0])) {
    if (rockOrLose.includes(i[2])) {
      score += 7;
      score2 += 2;
    }
    if (paperOrDraw.includes(i[2])) {
      score += 2;
      score2 += 6;
    }
    if (scissorsOrWin.includes(i[2])) {
      score += 6;
      score2 += 7;
    }
  }
});

console.log(score);
console.log(score2);
