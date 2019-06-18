# Locker Demo #

Please see code for a demo of proper locking in static classes, we must lock on a TYPE not an instance even a static one, or lock may not do what you intend.