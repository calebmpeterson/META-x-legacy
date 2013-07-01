(ns environment)

(def user-home (System.Environment/GetEnvironmentVariable "UserProfile"))
(defn in-user-home [relative-path] (str user-home "/" relative-path))
