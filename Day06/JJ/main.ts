function hasDuplicatesPerf(input, index, offset) {
  const chars = input.slice(index, index + offset);
  if (new Set([...chars]).size === offset) {
    return true;
  }
}

const input = await Deno.readTextFile("input.txt", "utf-8");

let hasFoundMarker1 = false;
let hasFoundMarker2 = false;
for (let i = 0; i < input.length; i++) {
  if (!hasFoundMarker1 && hasDuplicatesPerf(input, i, 4)) {
    console.log(i + 4);
    hasFoundMarker1 = true;
  }
  if (!hasFoundMarker2 && hasDuplicatesPerf(input, i, 14)) {
    console.log(i + 14);
    hasFoundMarker2 = true;
  }
}
