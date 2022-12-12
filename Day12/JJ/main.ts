const input = await Deno.readTextFile("input.txt", "utf-8");
// const input = await Deno.readTextFile("testInput.txt", "utf-8");

const maze: string[] = [];
const directions = [
  [1, 0],
  [0, 1],
  [0, -1],
  [-1, 0],
];

// let end = [52, 20];
const lines: string[] = input.split("\n");
lines.map((line) => maze.push(line));

const start = [];
let end;
const map = input.split("\n").map((line, i) =>
  line.split("").map((char, j) => {
    let height;
    // P1
    // if (char === "S") {
    // P2
    if (char === "a") {
      height = 0;
      start.push([i, j]);
    } else if (char === "E") {
      height = 25;
      end = [i, j];
    } else {
      height = char.codePointAt(0) - "a".codePointAt(0);
    }
    return height;
  })
);

const queue = start.map((start) => ({ position: start, steps: 0 }));
const visited = [];
while (queue.length) {
  const {
    position: [i, j],
    steps,
  } = queue.shift();
  if (visited[i]?.[j]) {
    continue;
  }
  if (i === end[0] && j === end[1]) {
    console.log(steps);
    break;
  }
  for (const [x, y] of directions) {
    if (
      !map[i + x]?.[j + y] ||
      map[i + x][j + y] > map[i][j] + 1 ||
      visited[i + x]?.[j + y]
    ) {
      continue;
    }
    queue.push({ position: [i + x, j + y], steps: steps + 1 });
  }
  visited[i] = visited[i] ?? [];
  visited[i][j] = 1;
}

console.log(end);
