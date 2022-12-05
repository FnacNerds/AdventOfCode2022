const inputRaw = await Deno.readTextFile("input.txt", "utf-8");
// const inputRaw = await Deno.readTextFile("testInput.txt", "utf-8");
const input = inputRaw.split("\n");

let count = 0;
while (true) {
  if (input[count].indexOf("[") > -1) {
    count++;
  } else {
    break;
  }
}

const numberOfStacks = Math.max(...input[count].split("").filter((s) => s));
// build stacks
let stacks = [];
for (let i = 1; i <= numberOfStacks; i++) {
  stacks[i] = [];
}
for (let i = 0; i < numberOfStacks; i++) {
  const element = input[i];
  for (let j = 1; j < numberOfStacks * 4 - 2; j += 4) {
    const e = element[j];
    if (RegExp(/^\p{L}/, "u").test(e)) {
      (stacks[(j - 1) / 4 + 1] as Array<string>).unshift(e);
    }
  }
}

// execute moves P1
for (let i = count + 2; i < input.length; i++) {
  const element = input[i];
  const move = element.match(/move (\d+) from (\d+) to (\d+)/);
  for (let j = 0; j < Number(move[1]); j++) {
    stacks[Number(move[3])].push(stacks[Number(move[2])].pop());
  }
}

let final = "";
for (let i = 1; i < stacks.length; i++) {
  final += stacks[i].pop();
}
console.log(final);

// reset stacks for P2
stacks = [];
for (let i = 1; i <= numberOfStacks; i++) {
  stacks[i] = [];
}
for (let i = 0; i < numberOfStacks; i++) {
  const element = input[i];
  for (let j = 1; j < numberOfStacks * 4 - 2; j += 4) {
    const e = element[j];
    if (RegExp(/^\p{L}/, "u").test(e)) {
      (stacks[(j - 1) / 4 + 1] as Array<string>).unshift(e);
    }
  }
}

// P2 moves
for (let i = count + 2; i < input.length; i++) {
  const element = input[i];
  const move = element.match(/move (\d+) from (\d+) to (\d+)/);
  for (let j = Number(move[1]); j > 0; j--) {
    stacks[Number(move[3])].push(
      stacks[Number(move[2])][stacks[Number(move[2])].length - j],
    );
    (stacks[Number(move[2])] as Array<string>).splice(
      stacks[Number(move[2])].length - j,
      1,
    );
  }
}

final = "";
for (let i = 1; i < stacks.length; i++) {
  final += stacks[i].pop();
}
console.log(final);
