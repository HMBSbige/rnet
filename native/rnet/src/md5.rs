use libc::*;
use md5::*;

/// # Safety
#[no_mangle]
pub unsafe extern "C" fn md5_new() -> *mut Md5 {
    Box::into_raw(Box::new(Md5::new()))
}

/// # Safety
#[no_mangle]
pub unsafe extern "C" fn md5_dispose(md5: *mut Md5) {
    Box::from_raw(md5);
}

/// # Safety
#[no_mangle]
pub unsafe extern "C" fn md5_reset(md5: *mut Md5) {
    let md5 = &mut *md5;
    md5.reset();
}

/// # Safety
#[no_mangle]
pub unsafe extern "C" fn md5_update_final(
    md5: *mut Md5,
    ptr: *const u8,
    size: size_t,
    ptr_out: *mut u8,
    size_out: size_t,
) {
    let md5 = &mut *md5;
    let slice = std::slice::from_raw_parts(ptr, size);
    md5.update(slice);
    let slice = std::slice::from_raw_parts_mut(ptr_out, size_out);
    slice.copy_from_slice(md5.finalize_reset().as_slice());
}

/// # Safety
#[no_mangle]
pub unsafe extern "C" fn md5_update(md5: *mut Md5, ptr: *const u8, size: size_t) {
    let md5 = &mut *md5;
    let slice = std::slice::from_raw_parts(ptr, size);
    md5.update(slice);
}

/// # Safety
#[no_mangle]
pub unsafe extern "C" fn md5_get_hash(md5: *mut Md5, ptr: *mut u8, size: size_t) {
    let md5 = &mut *md5;
    let slice = std::slice::from_raw_parts_mut(ptr, size);
    slice.copy_from_slice(md5.finalize_reset().as_slice());
}
