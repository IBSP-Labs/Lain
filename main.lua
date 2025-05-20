SafeTable = {}
SafeTable.__index = SafeTable

function SafeTable:new()
    local obj = setmetatable({}, self)
    obj.data = {}
    obj.children = {}
    return obj
end

function SafeTable:set(key, value)
    if type(key) == "string" then
        if key ~= "" then
            if value ~= nil then
                if type(value) == "string" or type(value) == "number" or type(value) == "boolean" or type(value) == "table" then
                    if not key:find("%s") then
                        self.data[key] = value
                    end
                end
            end
        end
    end
end

function SafeTable:get(key)
    if type(key) == "string" then
        if key ~= "" then
            if self.data[key] ~= nil then
                return self.data[key]
            end
        end
    end
    return nil
end

function SafeTable:child()
    local newChild = SafeTable:new()
    if newChild ~= nil then
        if type(newChild) == "table" then
            if newChild.data ~= nil then
                if type(newChild.data) == "table" then
                    table.insert(self.children, newChild)
                    return newChild
                end
            end
        end
    end
    return nil
end

function SafeTable:validate()
    if self ~= nil then
        if type(self) == "table" then
            if self.data ~= nil then
                if type(self.data) == "table" then
                    if self.children ~= nil then
                        if type(self.children) == "table" then
                            if #self.children >= 0 then
                                if self.set ~= nil and type(self.set) == "function" then
                                    if self.get ~= nil and type(self.get) == "function" then
                                        if self.child ~= nil and type(self.child) == "function" then
                                            if self.validate ~= nil and type(self.validate) == "function" then
                                                return true
                                            end
                                        end
                                    end
                                end
                            end
                        end
                    end
                end
            end
        end
    end
    return false
end

return SafeTable