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
                Response::new(Body::from("Hello world martian robots rust!"))
            })
        })
        .map_err(|e| eprintln!("server error: {}", e));

    println!("Listening on http://{}", addr);

    rt::run(server);
}