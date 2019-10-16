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

    let mut world = format!("world width {} height {}", width, height);
    
    while {
        let robot = parse_robot(&mut chars);
        world.push_str(format!("\n{}", robot).as_str());

        chars.next().is_some()
    } { }

    world
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

struct World {
    width: i32,
    height: i32,
    scents: Vec<(i32, i32)>,
}

struct Robot {
   x: i32,
   y: i32,
   orientation: i32,
   lost: bool,
}

struct ForwardCommand;

struct LeftCommand;

struct RightCommand;

trait Command {
    fn execute(&self, robot: &mut Robot, world: &mut World);
}

impl Command for ForwardCommand {
    fn execute(&self, robot: &mut Robot, world: &mut World) {
        let orientation_radians = f64::from(robot.orientation) * std::f64::consts::PI / 180f64;
        let x = (f64::from(robot.x) + orientation_radians.cos()) as i32;
        let y = (f64::from(robot.y) + orientation_radians.sin()) as i32;
        
        if x < 0 || x > world.width || y < 0 || y > world.height {
            if world.scents.contains(&(x, y)) {
                return;
            }
            
            world.scents.push((x, y));
            robot.lost = true;
            return;
        }
        
        robot.x = x;
        robot.y = y;
    }
}

impl Command for LeftCommand {
    fn execute(&self, robot: &mut Robot, _: &mut World) {
        robot.orientation -= 90;
    }
}

impl Command for RightCommand {
    fn execute(&self, robot: &mut Robot, _: &mut World) {
        robot.orientation += 90;
    }
}
