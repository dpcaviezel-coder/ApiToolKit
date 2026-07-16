# API Toolkit

A beginner-friendly C# toolkit for testing APIs, built to help new developers and QA engineers learn how to interact with HTTP endpoints in a clean, structured way.

## Current Features

### 1. GET Request Tool
Send GET requests to any API endpoint and view formatted JSON responses.

### 2. POST Request Tool
Send POST requests with JSON bodies and view formatted responses.

### 3. Status Code Validator
Check whether an endpoint returns the exact status code you expect.

### 4. Response Time Checker
Measure how long an API takes to respond and view the returned data.

### 5. Log Viewer
View all logged API operations in a simple text log.

### 6. Environment Profiles
Switch between `dev`, `qa`, and `prod` base URLs instantly.

### 7. Header Manager
Add, remove, and view custom headers (API keys, tokens, etc).

### 8. JSON Formatter
Automatically pretty‑prints JSON responses for readability.

### 9. Response Saver
Save the last API response to a `.json` file for later review.

### 10. Status Badge (QA Style)
Tracks PASS/FAIL for the last API operation using strict QA rules:
- GET → must return 200  
- POST → must return 201  
- DELETE → must return 200 or 204  
- Validator → expected must match actual  
- Response Time → must return 200  

### 11. DELETE Request Tool
Send DELETE requests, pretty‑print responses, save results, and apply QA PASS/FAIL rules.

---

More features coming soon!

