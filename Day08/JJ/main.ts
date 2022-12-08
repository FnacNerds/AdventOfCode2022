const input = await Deno.readTextFile("input.txt", "utf-8");
// const input = await Deno.readTextFile("testInput.txt", "utf-8");

const lines = input.split("\n");
let array: number[][] = [];
let visibleTrees: number[][] = [];
let scenicScore: number[][] = [];
let total = 0;
let max = 0;
for (let i = 0; i < lines.length; i++) {
  array[i] = lines[i]
    .trimEnd()
    .split("")
    .map((i) => +i);
  visibleTrees[i] = new Array(lines.length).fill(0);
  scenicScore[i] = new Array(lines.length).fill(0);
}

for (let i = 0; i < array.length; i++) {
  const line = array[i];
  for (let j = 0; j < line.length; j++) {
    const tree = array[i][j];
    let isHidden = false;
    let vn = 0;
    let vs = 0;
    let ve = 0;
    let vw = 0;
    // check edges
    if (
      visibleTrees[i][j] > -1 &&
      (i === 0 || j === 0 || i === array.length - 1 || j === line.length - 1)
    ) {
      visibleTrees[i][j] = -1;
      total++;
      continue;
    }

    // check up
    // console.log("up " + i + " ef " + j);
    if (i > 0) {
      //   console.log(" check ! " + tree);
      for (let t = i - 1; t >= 0; t--) {
        // console.log(" check ! dfdf" + array[t][j]);
        if (array[t][j] >= tree) {
          //   console.log("tree " + [i, j] + " is hidden up ! " + (i - t));
          vn = i - t;
          isHidden = true;
          break;
        }
      }
      if (!isHidden) {
        visibleTrees[i][j] = -1;
        total++;
        // console.log(visibleTrees);
      }
      vn = vn > 0 ? vn : i;
    }

    // check down
    // console.log("down");
    isHidden = false;
    if (i < array.length - 1) {
      for (let t = i + 1; t < array.length; t++) {
        if (array[t][j] >= tree) {
          //   console.log("tree " + [i, j] + " is hidden down ! " + (t - i));
          vs = t - i;
          isHidden = true;
          break;
        }
      }
      if (!isHidden) {
        visibleTrees[i][j] = -1;
        total++;
        // console.log(visibleTrees);
      }
      vs = vs > 0 ? vs : array.length - 1 - i;
    }

    // check east
    // console.log("east");
    isHidden = false;
    if (i < array.length - 1) {
      for (let t = j + 1; t < array[i].length; t++) {
        if (array[i][t] >= tree) {
          //   console.log("tree " + [i, j] + " is hidden east ! " + (t - j));
          ve = t - j;
          isHidden = true;
          break;
        }
      }
      if (!isHidden) {
        visibleTrees[i][j] = -1;
        total++;
        // console.log(visibleTrees);
      }
      ve = ve > 0 ? ve : array[i].length - 1 - j;
    }

    // check west
    // console.log("west");
    isHidden = false;
    if (i < array.length - 1) {
      for (let t = j - 1; t >= 0; t--) {
        if (array[i][t] >= tree) {
          //   console.log("tree " + [i, j] + " is hidden west ! " + (j - t));
          vw = j - t;
          isHidden = true;
          break;
        }
      }
      if (!isHidden) {
        visibleTrees[i][j] = -1;
        total++;
        // console.log(visibleTrees);
      }
      vw = vw > 0 ? vw : j;
    }
    // console.log(" vn " + vn);
    // console.log(" vn " + vs);
    // console.log(" vn " + ve);
    // console.log(" vn " + vw);
    scenicScore[i][j] = vn * ve * vs * vw;
    if (scenicScore[i][j] > max) {
      max = scenicScore[i][j];
    }
    // console.log(visibleTrees);
  }
}
// console.log(total);
console.log(max);
