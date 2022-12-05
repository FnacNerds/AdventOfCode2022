use std::fs;
use std::io::{BufRead, BufReader};

fn main() -> std::io::Result<()> {
    let mut reader = BufReader::new(fs::File::open("input.txt")?);
    let mut res: Vec<u32> = Vec::new();
    let mut count = 0;
    loop {
        let mut buff = String::new();
        reader.read_line(&mut buff)?;
        if buff.is_empty() {
            res.sort_by(|a, b| b.cmp(a));
            println!("{}", &res[0]);
            println!("{}", &res[0] + &res[1] + &res[2]);
            return Ok(());
        }
        
        buff = buff.trim_end().to_string();
        if buff == "" {
            res.push(count);
            count = 0;
            continue;
        }

        count += buff.parse::<u32>().unwrap()
    }
}
