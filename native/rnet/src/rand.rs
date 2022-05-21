use libc::*;
use rand::*;

/// # Safety
#[no_mangle]
pub unsafe extern "C" fn rand_fill(ptr: *mut u8, size: size_t) -> ssize_t {
    let slice = std::slice::from_raw_parts_mut(ptr, size);
    let result = rand::thread_rng().try_fill_bytes(slice);
    match result {
        Ok(_) => 0,
        Err(_) => 1,
    }
}
