const input = await Deno.readTextFile("input.txt", "utf-8");
// const input = await Deno.readTextFile("testInput.txt", "utf-8");

const sizes = { "/": 0 };
const arbo = ["/"];
const lines = input.split("\n");
for (let i = 1; i < lines.length; i++) {
  const [, cmd, dir] = lines[i].replace(/(\r\n|\n|\r)/gm, "").split(" ");
  if (cmd === "ls") {
    // console.log(cmd);
    for (i++; i < lines.length; i++) {
      const parts = lines[i].split(" ");
      if (parts[0] === "$") {
        i--;
        break;
      }
      if (parts[0] !== "dir") {
        for (const path of arbo) {
          sizes[path] = (sizes[path] ?? 0) + +parts[0];
        }
      }
    }
  } else {
    if (dir === "..") {
      arbo.pop();
    } else {
      arbo.push(`${arbo.at(-1)}${dir}/`);
    }
  }
}

// console.log(sizes);
console.log(
  Object.values(sizes)
    .filter((size) => size <= 100000)
    .reduce((acc, size) => acc + size)
);

console.log(
  Math.min(
    ...Object.values(sizes).filter((size) => size >= sizes["/"] - 40000000)
  )
);
