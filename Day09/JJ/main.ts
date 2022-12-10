// const input = await Deno.readTextFile("testInput.txt", "utf-8");
// const input = await Deno.readTextFile("testInput2.txt", "utf-8");
const input = await Deno.readTextFile("input.txt", "utf-8");

const knots = [
  [0, 0],
  [0, 0],
  [0, 0],
  [0, 0],
  [0, 0],
  [0, 0],
  [0, 0],
  [0, 0],
  [0, 0],
  [0, 0],
];
const positions = [[0, 0]];
let count = 0;
input.split("\n").map((line) => {
  count++;
  const [direction, steps] = line.split(" ");
  for (let i = 0; i < steps; i++) {
    if (direction === "U") {
      knots[0][1] = knots[0][1] + 1;
    }
    if (direction === "D") {
      knots[0][1] = knots[0][1] - 1;
    }
    if (direction === "R") {
      knots[0][0] = knots[0][0] + 1;
    }
    if (direction === "L") {
      knots[0][0] = knots[0][0] - 1;
    }

    for (let j = 1; j < knots.length; j++) {
      // if not adjacent
      if (
        !(
          Math.abs(knots[j - 1][0] - knots[j][0]) <= 1 &&
          Math.abs(knots[j - 1][1] - knots[j][1]) <= 1
        )
      ) {
        // same vertical
        if (knots[j - 1][1] !== knots[j][1]) {
          if (knots[j - 1][1] > knots[j][1]) {
            knots[j] = [knots[j][0], knots[j][1] + 1];
          } else {
            knots[j] = [knots[j][0], knots[j][1] - 1];
          }
        }
        if (knots[j - 1][0] !== knots[j][0]) {
          if (knots[j - 1][0] > knots[j][0]) {
            knots[j] = [knots[j][0] + 1, knots[j][1]];
          } else {
            knots[j] = [knots[j][0] - 1, knots[j][1]];
          }
        }
        if (
          j === knots.length - 1 &&
          positions.filter((location) => {
            return location[0] === knots[j][0] && location[1] === knots[j][1];
          }).length < 1
        ) {
          positions.push(knots[j]);
        }
      }
    }
  }
  // console.log(knots);
});

console.log(positions.length);
