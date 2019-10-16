#![deny(warnings)]
extern crate hyper;

use std::env;
use hyper::{Body, Request, Response, Server};
use hyper::service::service_fn_ok;
use hyper::rt::{self, Future};

fn main() {
    let port = match env::var("HTTP_PLATFORM_PORT") {
        Ok(val) => val,
        Err(_e) => "6767".to_string(),
    };
    let addr = format!("127.0.0.1:{}", port).parse().unwrap();

    let server = Server::bind(&addr)
        .serve(|| {
            service_fn_ok(move |_: Request<Body>| {
                let input = "
5 3
1 1 E
RFRFRFRF

3 2 N
FRRFLLFFRRFLL

0 3 W
LLFFFLFLFL
".trim().to_string();

                let world = parse_world(input);

                Response::new(Body::from(world))
            })
        })
        .map_err(|e| eprintln!("server error: {}", e));

    println!("Listening on http://{}", addr);

    rt::run(server);
}

fn parse_world(input: String) -> String {
    let mut chars = input.chars();

    let width = parse_integer(&mut chars);
    let height = parse_integer(&mut chars);
    println!("world width {} height {}", width, height);

    let robot1 = parse_robot(&mut chars);
    let robot2 = parse_robot(&mut chars);
    let robot3 = parse_robot(&mut chars);
    
    format!("{}\n{}\n{}", robot1, robot2, robot3)
}

fn parse_integer(chars: &mut std::str::Chars) -> i32 {
    chars
        .take_while(|c| c.is_numeric())
        .collect::<String>()
        .parse::<i32>()
        .unwrap()
}

// TODO: return robot, not string
fn parse_robot(chars: &mut std::str::Chars) -> String { 
    let x = parse_integer(chars);
    let y = parse_integer(chars);
    let orientation = parse_orientation(chars);
    chars.next(); 
    let commands = parse_commands(chars);
    chars.next();
    
    format!("robot x {} y {} orientation {} commands {}", x, y, orientation, commands)
}

fn parse_orientation(chars: &mut std::str::Chars) -> i32 {
    match chars.next() {
        Some('N') => 90,
        Some('E') => 0,
        Some('S') => 270,
        Some('W') => 180,
        Some(orientation) => panic!("Unexpected orientation value {}", orientation),
        None => panic!("Missing orientation")
    }
}

// TODO: return command, not string
fn parse_commands(chars: &mut std::str::Chars) -> String {
    chars
        .take_while(|c| c.is_alphabetic())
        .collect::<String>()
}
